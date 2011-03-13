structureString
	"Return a string that showing this morph and all its submorphs in an indented list that reflects its structure."

	| s |
	s := (String new: 1000) writeStream.
	self printStructureOn: s indent: 0.
	^ s contents
