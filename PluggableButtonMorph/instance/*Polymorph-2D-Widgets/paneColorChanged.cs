paneColorChanged
	"Update the fillStyle here.
	Optimised to not send #changed if no changes."

	|lc pc|
	self borderStyle: self borderStyleToUse.
	self fillStyle: self fillStyleToUse.
	(self labelMorph isNil
			or: [(self labelMorph respondsTo: #enabled:)
			or: [label isMorph]]) ifFalse: [
		pc := self normalColor.
		lc := self enabled
			ifTrue: [pc contrastingColor]
			ifFalse: [pc contrastingColor muchDarker].
		self labelMorph color: lc]