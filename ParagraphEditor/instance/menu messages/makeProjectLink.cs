makeProjectLink
	
	| attribute thisSel |
	
	thisSel := self selection.

	attribute := TextSqkProjectLink new. 
	thisSel := attribute analyze: self selection asString.

	thisSel ifNil: [^ true].
	self replaceSelectionWith: (thisSel asText addAttribute: attribute).
	^ true