namespace record_create {
    function getIntValue(id: string): number | null {
        const VALUE = (document.getElementById(id) as HTMLInputElement | HTMLSelectElement).value;
        return VALUE === "" ? null : parseInt(VALUE);
    }
    
    export function save(): void {
        const RAW_DATE = (document.getElementById("Date") as HTMLInputElement).value;
        const PARSED_DATE = new Date(`${RAW_DATE}T00:00:00`);
        const DATE_ISO = PARSED_DATE.toISOString();

        const RECORD = {
            Date: DATE_ISO,
            Handwriting: (document.getElementById("Handwriting") as HTMLInputElement).value,
            Pronunciation: (document.getElementById("Pronunciation") as HTMLInputElement).value,
            Meaning: (document.getElementById("Meaning") as HTMLInputElement).value,
            Category: getIntValue("Category")
        };

        fetch("/Entries/Create?handler=Save", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(RECORD)
        })
            .then(response => {
                if (!response.ok) throw new Error("Error en la respuesta");
                return response.json();
            })
            .then(data => {
                if (!data.success) {
                    alert(data.message);
                    return;
                }

                // Guardamos el ID como atributo en el botón
                const BTN = document.getElementById("btnSave");
                if (BTN) {
                    BTN.setAttribute("data-id", data.id);
                }

                window.location.href = `/Entries/Details?ID=${encodeURIComponent(data.id)}`;
            })
            .catch(error => {
                alert(`Error al guardar el plan de vuelo: ${error.message}`);
            });
    }
}