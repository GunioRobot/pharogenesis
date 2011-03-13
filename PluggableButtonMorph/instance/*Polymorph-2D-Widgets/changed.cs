changed
	"Update the fillStyle here."

	|lc pc bs|
	self borderWidth > 0 ifTrue: [
		self setProperty: #borderStyle toValue: (bs := self borderStyleToUse).
		borderColor := bs style.
		borderWidth := bs width].
	self setProperty: #fillStyle toValue: self fillStyleToUse..
	self layoutInset: (self theme buttonLabelInsetFor: self).
	color := self fillStyle asColor.
	(self labelMorph respondsTo: #enabled:)
		ifTrue: [self labelMorph enabled: self enabled]
		ifFalse: [(self labelMorph isNil
			or: [label isMorph]) ifFalse: [
				pc := self normalColor.
				lc := self enabled
					ifTrue: [pc contrastingColor]
					ifFalse: [pc contrastingColor muchDarker].
				self labelMorph color: lc]].
	super changed