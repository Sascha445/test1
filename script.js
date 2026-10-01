// ARRAY VAN PROJECTEN

const projecten = [
    {
        naam: "Project 1",
        categorie: "Web",
        beschrijving: "In mijn vorige jaar heb ik gewerkt aan een Watertappunten-app. (Web)",
        afbeelding: "watertappunt.png"
    },
    {
        naam: "Project 2",
        categorie: "Java",
        beschrijving: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. (Java)"
    },
    {
        naam: "Project 3",
        categorie: "Web",
        beschrijving: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. (Web)"
    },
    {
        naam: "Project 4",
        categorie: "Overig",
        beschrijving: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. (Overig)"
    }
];

// FUNCTIE OM PROJECTEN TE TONEN

const projectenContainer = document.getElementById("projecten");
const categorieFilter = document.getElementById("categorieFilter");

function showProjects(projectenOmTeTonen) {
    projectenContainer.innerHTML = "";

    projectenOmTeTonen.forEach(function(project) {
        const article = document.createElement("article");

        const titel = document.createElement("h3");
        titel.textContent = project.naam;

        const beschrijving = document.createElement("p");
        beschrijving.textContent = project.beschrijving;
        beschrijving.style.display = "none";

        const knop = document.createElement("button");
        knop.textContent = "Meer informatie";

        article.appendChild(titel);
        article.appendChild(knop);
        article.appendChild(beschrijving);

        let afbeelding;

        if (project.afbeelding) {
            afbeelding = document.createElement("img");
            afbeelding.src = project.afbeelding;
            afbeelding.alt = project.naam;
            afbeelding.style.display = "none";

            article.appendChild(afbeelding);
        }

        knop.addEventListener("click", function() {
            if (beschrijving.style.display === "none") {
                beschrijving.style.display = "block";

                if (afbeelding) {
                    afbeelding.style.display = "block";
                }

                knop.textContent = "Minder informatie";
            } else {
                beschrijving.style.display = "none";

                if (afbeelding) {
                    afbeelding.style.display = "none";
                }

                knop.textContent = "Meer informatie";
            }
        });

        projectenContainer.appendChild(article);
    });
}
// INITIALISATIE
if (projectenContainer) {
    showProjects(projecten);
}

// FILTEREN OP CATEGORIE
if (categorieFilter) {
    categorieFilter.addEventListener("change", function() {
        const gekozenCategorie = categorieFilter.value;

        if (gekozenCategorie === "alle") {
            showProjects(projecten);
        } else {
            const gefilterdeProjecten = projecten.filter(function(project) {
                return project.categorie === gekozenCategorie;
            });

            showProjects(gefilterdeProjecten);
        }
    });
}

// CONTACTFORMULIER VALIDEREN
const contactForm = document.getElementById("contactForm");

if (contactForm) {

    const naam = document.getElementById("naam");
    const email = document.getElementById("email");
    const bericht = document.getElementById("bericht");

    const naamFout = document.getElementById("naamFout");
    const emailFout = document.getElementById("emailFout");
    const berichtFout = document.getElementById("berichtFout");
    const succesMelding = document.getElementById("succesMelding");

    contactForm.addEventListener("submit", function(event) {
        event.preventDefault();

        valideerFormulier();
    });

    function valideerFormulier() {
        let geldig = true;

        naamFout.textContent = "";
        emailFout.textContent = "";
        berichtFout.textContent = "";
        succesMelding.textContent = "";

        if (naam.value.trim() === "") {
            naamFout.textContent = "Vul je naam in.";
            geldig = false;
        }

        if (!email.value.includes("@")) {
            emailFout.textContent = "Vul een geldig e-mailadres in.";
            geldig = false;
        }

        if (bericht.value.trim().length < 10) {
            berichtFout.textContent = "Je bericht moet minimaal 10 tekens bevatten.";
            geldig = false;
        }

        if (geldig) {
            succesMelding.textContent = "Je bericht is succesvol verstuurd!";
            contactForm.reset();
        }
    }
}


// WEER FETCH

const weerStatus = document.getElementById("weerStatus");
const temperatuur = document.getElementById("temperatuur");
const windsnelheid = document.getElementById("windsnelheid");

if (weerStatus) {
    haalWeerOp();
}

function haalWeerOp() {
    fetch("https://api.open-meteo.com/v1/forecast?latitude=52.0705&longitude=4.3007&current=temperature_2m,wind_speed_10m")
        .then(function(response) {
            if (!response.ok) {
                throw new Error("Er ging iets mis met het ophalen van het weer.");
            }

            return response.json();
        })
        .then(function(data) {
            temperatuur.textContent = "Temperatuur: " + data.current.temperature_2m + " °C";
            windsnelheid.textContent = "Windsnelheid: " + data.current.wind_speed_10m + " km/u";
            weerStatus.textContent = "Actuele gegevens uit Den Haag:";
        })
        .catch(function(error) {
            weerStatus.textContent = "Het weer kon niet worden opgehaald.";
        });
}