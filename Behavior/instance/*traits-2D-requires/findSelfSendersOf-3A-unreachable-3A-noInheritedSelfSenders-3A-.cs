findSelfSendersOf: selector unreachable: unreachableCollection noInheritedSelfSenders: noInheritedBoolean
	"This method answers a subset of all the reachable methods (local or inherited) that self-send selector (empty set => no self-senders).
	See Nathanael Sch䲬i's PhD for more details."
	
	| selfSenders reachableSelfSenders translations |
	"Check whether there are local methods that self-send selector and are reachable."
	selfSenders := self sendCaches selfSendersOf: selector.
	reachableSelfSenders := FixedIdentitySet readonlyWithAll: selfSenders notIn: unreachableCollection.
	(self superclass isNil or: [noInheritedBoolean or: [reachableSelfSenders notEmpty]]) 
		ifTrue: [^ reachableSelfSenders].

	"Compute the set of unreachable superclass methods and super-send translations and recurse."
	translations := self computeTranslationsAndUpdateUnreachableSet: unreachableCollection.
	reachableSelfSenders := superclass findSelfSendersOf: selector unreachable: unreachableCollection noInheritedSelfSenders: false.
	
	"Use the translations to replace selectors that are super-sent with the methods that issue the super-sends."
	reachableSelfSenders := self translateReachableSelfSenders: reachableSelfSenders translations: translations.
	^ reachableSelfSenders.