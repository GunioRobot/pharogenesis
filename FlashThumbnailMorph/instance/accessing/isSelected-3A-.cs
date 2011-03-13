isSelected: aBoolean
	selected == aBoolean ifTrue:[^self].
	selected := aBoolean.
	self borderColor: (self isSelected ifTrue:[Color red] ifFalse:[Color black]).