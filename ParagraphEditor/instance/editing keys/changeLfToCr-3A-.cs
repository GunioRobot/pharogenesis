changeLfToCr: characterStream 
	"Replace all LFs by CRs.
	Triggered by Cmd-U -- useful when getting code from FTP sites"
	| cr lf |
	cr := Character cr.  lf := Character linefeed.
	self replaceSelectionWith: (Text fromString:
			(self selection string collect: [:c | c = lf ifTrue: [cr] ifFalse: [c]])).
	^ true