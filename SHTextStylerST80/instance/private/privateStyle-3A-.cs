privateStyle: aText

	| ranges |
	ranges := self rangesIn: aText setWorkspace: true.
	ranges ifNotNil: [self setAttributesIn: aText fromRanges: ranges]