browseStream: aStream named: aString

	| package organizer packageDict browser |
	Cursor wait showWhile: [
		packageDict _ Dictionary new.
		organizer _ SystemOrganizer defaultList: Array new.
		(aStream respondsTo: #converter:) ifTrue: [
			aStream setConverterForCode.
		].
		package _ (FilePackage new fullName: aString; fileInFrom: aStream).
		packageDict 
			at: package packageName 
			put: package.
		organizer 
			classifyAll: package classes keys 
			under: package packageName.
		(browser := self new)
			systemOrganizer: organizer;
			packages: packageDict].
	self
		openBrowserView: browser createViews
		label: 'File Contents Browser'.
