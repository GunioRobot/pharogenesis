scaleFactor: newScale 
	"Backstop for morphs that don't have to do something special to set their 
	scale "
	| toBeScaled |
	toBeScaled := self.
	newScale = 1.0
		ifTrue: [(self heading isZero
					and: [self isFlexMorph])
				ifTrue: [toBeScaled := self removeFlexShell]]
		ifFalse: [self isFlexMorph
				ifFalse: [toBeScaled := self addFlexShellIfNecessary]].

	toBeScaled scale: newScale.

	toBeScaled == self ifTrue: [
		newScale = 1.0
			ifTrue: [ self removeProperty: #scaleFactor ]
			ifFalse: [ self setProperty: #scaleFactor toValue: newScale ]]