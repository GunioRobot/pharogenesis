decorateMenu: aMenu 
	"decorate aMenu with icons"
	| numberAdded |
	Preferences menuWithIcons
		ifFalse: [^ self].
	numberAdded := 0.
	aMenu items do: [ :item | | icon |
		item icon isNil ifTrue:[
			icon _ self iconForMenuItem: item.
			icon ifNotNil: [
				item icon: icon.
				numberAdded := numberAdded + 1. ]]].

	numberAdded isZero ifTrue: [^ self].
	aMenu addBlankIconsIfNecessary: self blankIcon