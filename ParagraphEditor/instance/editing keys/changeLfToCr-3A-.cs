changeLfToCr: characterStream 
	"Replace all LFs by CRs.
	Triggered by Cmd-U -- useful when getting code from FTP sites"
	| cr lf |
	sensor keyboard.		"flush the triggering cmd-key character"
	cr _ Character cr.  lf _ Character linefeed.
	self replaceSelectionWith: (Text fromString:
			(self selection string collect: [:c | c = lf ifTrue: [cr] ifFalse: [c]])).
	^ true