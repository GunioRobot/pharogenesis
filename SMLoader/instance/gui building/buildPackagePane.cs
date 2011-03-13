buildPackagePane
	"Create the text area to the right in the loader."

	| ptm |
	ptm := PluggableTextMorph 
		on: self 
		text: #contents
		accept: nil
		readSelection: nil "#packageSelection "
		menu: nil.
	ptm setBalloonText: 'This is where the selected package or package release is displayed.'.
	ptm lock.
	^ptm