serviceOpenVersion
	^ (SimpleServiceEntry
		provider: self
		label: 'open version'
		selector: #openVersionFromStream:
		description: 'open a package version'
		buttonLabel: 'open')
		argumentGetter: [ :fileList | fileList readOnlyStream ]