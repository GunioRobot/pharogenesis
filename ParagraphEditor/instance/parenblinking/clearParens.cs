clearParens
	lastParentLocation ifNotNil:
		[self text string size >= lastParentLocation ifTrue: [
			self text
				removeAttribute: TextEmphasis bold
				from: lastParentLocation
				to: lastParentLocation]]
