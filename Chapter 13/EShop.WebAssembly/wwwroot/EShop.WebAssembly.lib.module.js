let resources = [];
export async function beforeStart(options) {
    options.loadBootResource = function (_, name, uri) {
        resources.push([name, uri]);
        return uri;
    }
    const before = document.createElement('p');
    before.setAttribute('id', 'beforeStart');
    before.innerText = 'execute beforeStart';
    before.style = 'background-color: red; color: white';
    document.body.appendChild(before);
}

export async function afterStarted() {
    const after = document.createElement('p');
    after.setAttribute('id', 'afterStarted');
    after.innerText = 'execute afterStarted';
    after.style = 'background-color: green; color: white';
    document.body.appendChild(after);

    if (resources.length > 0) {

        const resourceRow = (row) => `<tr><td>${row[0]}</td><td>${row[1]}</td></tr>`;
        const rows = resources.reduce((previewRows, currentRow) => previewRows + resourceRow(currentRow), '');

        const resourceTable = document.createElement('table');
        resourceTable.setAttribute('id', 'resources');
        resourceTable.style = 'color: white; width: 100%; background-color: green; cellpadding: 1;';
        resourceTable.innerHTML = `
<tr>
<th>resource-name</th>
<th>resource-uri</th>
</tr>
${rows}
`;
        document.body.appendChild(resourceTable);
    }
}