const projecten = [
    {
        naam: "Project 1",
        categorie: "Web",
        beschrijving: "In mijn vorige jaar heb ik gewerkt aan een Watertappunten-app.",
        afbeelding: "watertappunt.png"
    },
    {
        naam: "Project 2",
        categorie: "Java",
        beschrijving: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
    },
    {
        naam: "Project 3",
        categorie: "Web",
        beschrijving: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
    },
    {
        naam: "Project 4",
        categorie: "Overig",
        beschrijving: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
    }
];

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

showProjects(projecten);

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