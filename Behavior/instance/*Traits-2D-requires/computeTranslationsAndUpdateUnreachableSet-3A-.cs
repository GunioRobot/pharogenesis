computeTranslationsAndUpdateUnreachableSet: unreachableCollection
	"This method computes the set of unreachable selectors in the superclass by altering the set of unreachable selectors in this class. In addition, it builds a dictionary mapping super-sent selectors to the selectors of methods sending these selectors."

	| translations reachableSenders oldUnreachable |
	oldUnreachable _ unreachableCollection copy.
	translations _ IdentityDictionary new.
	"Add selectors implemented in this class to unreachable set."
	self methodDict keysDo: [:s | unreachableCollection add: s].
	
	"Fill translation dictionary and remove super-reachable selectors from unreachable."
	self sendCaches superSentSelectorsAndSendersDo: [:sent :senders |
		reachableSenders _ FixedIdentitySet readonlyWithAll: senders notIn: oldUnreachable.
		reachableSenders isEmpty ifFalse: [
			translations at: sent put: reachableSenders.
			unreachableCollection remove: sent ifAbsent: [].
		].
	].
	^ translations