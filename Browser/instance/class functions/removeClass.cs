removeClass
	"The selected class should be removed from the system. Use a Confirmer 
	to make certain the user intends this irrevocable command to be carried 
	out."
	| message class className |
	classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	class _ self selectedClass.
	className _ class name.
	message _ 'Are you certain that you
want to delete the class ', className, '?'.
	(self confirm: message) ifTrue: 
			[class subclasses size > 0
				ifTrue: [self notify: 'class has subclasses: ' , message].
			class removeFromSystem.
			self classListIndex: 0].
	self changed: #classList.
