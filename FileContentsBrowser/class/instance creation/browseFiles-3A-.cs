browseFiles: fileList

	| package organizer packageDict browser |
	Cursor wait showWhile: [
		packageDict _ Dictionary new.
		organizer _ SystemOrganizer defaultList: Array new.
		fileList do: [:fileName |
			package _ FilePackage fromFileNamed: fileName.
			packageDict 
				at: package packageName 
				put: package.
			organizer 
				classifyAll: package classes keys 
				under: package packageName].
		(browser := self new)
			systemOrganizer: organizer;
			packages: packageDict].
	self
		openBrowserView: browser createViews
		label: 'File Contents Browser'.
