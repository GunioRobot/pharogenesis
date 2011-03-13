testFinalizationOfEquals
	"self run: #testFinalizationOfEquals"
	
	| finalizationProbe o1 o2
	forAnyTwoEqualObjects
	ofDifferentIdentity
	registeringAnActionAtFinalizationForEachObject
	thenForcingFinalizationOfObjects
	implyBothRegisteredActionsAreExecuted |

	finalizationProbe := Set new.
	o1 := 'hello' copy.
	o2 := 'hello' copy.
	forAnyTwoEqualObjects := [o1 = o2].
	ofDifferentIdentity := [o1 ~~ o2].
	registeringAnActionAtFinalizationForEachObject := [
		o1 toFinalizeSend: #add: to: finalizationProbe	with: 'first object finalized'.
		o2 toFinalizeSend: #add: to: finalizationProbe	with: 'second object finalized'].
	thenForcingFinalizationOfObjects := [
		o1 := o2 := nil. Smalltalk garbageCollect].
	implyBothRegisteredActionsAreExecuted := [finalizationProbe size = 2].

	self
		assert: forAnyTwoEqualObjects;
		assert: ofDifferentIdentity;
		should: [
			registeringAnActionAtFinalizationForEachObject value.
			thenForcingFinalizationOfObjects value.
			implyBothRegisteredActionsAreExecuted value].