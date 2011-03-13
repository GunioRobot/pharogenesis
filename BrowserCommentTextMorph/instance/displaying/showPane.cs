showPane
	"Fixed to not keep doing the splitters. If we are showing don't show again!"
	
	| win |
	self owner ifNil: [
		win := self window ifNil: [ ^self ].
		win addMorph: self fullFrame: self layoutFrame.
		win updatePanesFromSubmorphs.
		self lowerPane ifNotNil: [ :lp | lp layoutFrame bottomFraction: self layoutFrame topFraction ].
		win addPaneSplitters]