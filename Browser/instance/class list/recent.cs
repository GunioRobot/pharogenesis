recent
	"Let the user select from a list of recently visited classes.  11/96 stp.
	 12/96 di:  use class name, not classes themselves.
	 : dont fall into debugger in empty case"

	| className class recentList |
	recentList _ RecentClasses select: [:n | Smalltalk includesKey: n].
	recentList size == 0 ifTrue: [^ self beep].
	className := (SelectionMenu selections: recentList) startUp.
	className == nil ifTrue: [^ self].
	class := Smalltalk at: className.
	self selectCategoryForClass: class.
	self classListIndex: (self classList indexOf: class name)