event: anEvent
	"Hook for SystemChangeNotifier"

	(anEvent isRemoved and: [anEvent itemKind = SystemChangeNotifier classKind]) 
		ifTrue: [self noteRemovalOf: anEvent item].
	(anEvent isAdded and: [anEvent itemKind = SystemChangeNotifier classKind]) 
		ifTrue: [self addClass: anEvent item].
	(anEvent isModified and: [anEvent itemKind = SystemChangeNotifier classKind])
		ifTrue: [anEvent anyChanges ifTrue: [self changeClass: anEvent item from: anEvent oldItem]].
	(anEvent isCommented and: [anEvent itemKind = SystemChangeNotifier classKind])
		ifTrue: [self commentClass: anEvent item].
	(anEvent isAdded and: [anEvent itemKind = SystemChangeNotifier methodKind])
		ifTrue: [self noteNewMethod: anEvent item forClass: anEvent itemClass selector: anEvent itemSelector priorMethod: nil].
	(anEvent isModified and: [anEvent itemKind = SystemChangeNotifier methodKind])
		ifTrue: [self noteNewMethod: anEvent item forClass: anEvent itemClass selector: anEvent itemSelector priorMethod: anEvent oldItem].
	(anEvent isRemoved and: [anEvent itemKind = SystemChangeNotifier methodKind])
		ifTrue: [self removeSelector: anEvent itemSelector class: anEvent itemClass priorMethod: anEvent item lastMethodInfo: {anEvent item sourcePointer. anEvent itemProtocol}].
	(anEvent isRenamed and: [anEvent itemKind = SystemChangeNotifier classKind])
		ifTrue: [self renameClass: anEvent item as: anEvent newName].
	(anEvent isReorganized and: [anEvent itemKind = SystemChangeNotifier classKind])
		ifTrue: [self reorganizeClass: anEvent item].
	(anEvent isRecategorized and: [anEvent itemKind = SystemChangeNotifier methodKind])
		ifTrue: [self reorganizeClass: anEvent itemClass].