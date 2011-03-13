detachSubMenu: evt
	| possibleTargets item subMenu index |
	possibleTargets _ self items select:[:any| any hasSubMenu].
	possibleTargets size > 0 ifTrue:[
		index _ PopUpMenu 
				withCaption:'Which menu?' 
				chooseFrom: (possibleTargets collect:[:t| t contents asString]).
		index = 0 ifTrue:[^self]].
	item _ possibleTargets at: index.
	subMenu _ item subMenu.
	subMenu ifNotNil: [
		item subMenu: nil.
		item delete.
		subMenu stayUp: true.
		subMenu popUpOwner: nil.
		subMenu addTitle: item contents.
		evt hand attachMorph: subMenu].
