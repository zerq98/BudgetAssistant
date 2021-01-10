document.addEventListener('DOMContentLoaded', () => {
    var catDialog = document.getElementById("categoryDialog");
	var newTabButton = document.getElementById("newCat");
	var newExpButtons = document.querySelectorAll("#newExp");
	var expDialog = document.getElementById("expenseDialog");
	var catId = document.getElementById("categoryId");

    newTabButton.addEventListener("click", () => {
        catDialog.style.display = "block";
    });

    catDialog.addEventListener("click", e => {
        if (!e.target.matches('#dialog') && !e.target.matches('#frm')) {
            catDialog.style.display = "none";
        }
	});

	newExpButtons.forEach((e) => {
		e.addEventListener("click", () => {
			expDialog.style.display = "block";
			console.log(e.getAttribute("data-catId"));
			catId.value = e.getAttribute("data-catId");
		});
	});

	expDialog.addEventListener("click", e => {
		if (!e.target.matches('#dialog') && !e.target.matches('#frm')) {
			expDialog.style.display = "none";
		}
	});

	const labels = document.querySelectorAll(".accordion-item__label");
	const tabs = document.querySelectorAll(".accordion-tab");

	function toggleShow() {
		const target = this;
		const item = target.classList.contains("accordion-tab")
			? target
			: target.parentElement;
		const group = item.dataset.actabGroup;
		const id = item.dataset.actabId;

		tabs.forEach(function (tab) {
			if (tab.dataset.actabGroup === group) {
				if (tab.dataset.actabId === id) {
					tab.classList.add("accordion-active");
				} else {
					tab.classList.remove("accordion-active");
				}
			}
		});

		labels.forEach(function (label) {
			const tabItem = label.parentElement;

			if (tabItem.dataset.actabGroup === group) {
				if (tabItem.dataset.actabId === id) {
					tabItem.classList.add("accordion-active");
					tabItem.classList.add("accordion-itemActive");
				} else {
					tabItem.classList.remove("accordion-active");
					tabItem.classList.remove("accordion-itemActive");
				}
			}
		});
	}

	labels.forEach(function (label) {
		label.addEventListener("click", toggleShow);
	});

	tabs.forEach(function (tab) {
		tab.addEventListener("click", toggleShow);
	});
})