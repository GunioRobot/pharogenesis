buildSearchPane
	| typeInView |
	typeInView := PluggableTextMorph on: self 
		text: nil accept: #findPackage:notifying:
		readSelection: nil menu: nil.
	typeInView setBalloonText:'To find a package type in a fragment of its name and hit return'.
	typeInView acceptOnCR: true.
	(typeInView respondsTo: #hideScrollBarsIndefinitely) ifTrue: [
		typeInView hideScrollBarsIndefinitely]
	ifFalse: [typeInView hideScrollBarIndefinitely].
	^typeInView