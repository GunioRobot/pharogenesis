testObjects: dataObjects strings: dataStrings
	| dataObjs dataStrs selectors classes didUnmodifiedAnswer answerMod do ds result ddo dds |
	"Try to make substitutions in the user's inputs and search for the selector again.
1 no change to answer.
2 answer Array -> OrderedCollection.
2 answer Character -> String
4 answer Symbol or String of len 1 -> Character
	For each of these, try straight, and try converting args:
Character -> String
Symbol or String of len 1 -> Character
	Return array with result, dataObjects, dataStrings.  Don't ever do a find on the same set of data twice."

dataObjs _ dataObjects.  dataStrs _ dataStrings.
selectors _ {#asString. #first. #asOrderedCollection}.
classes _ {Character. String. Array}.
didUnmodifiedAnswer _ false.
selectors withIndexDo: [:ansSel :ansInd | "Modify the answer object"
	answerMod _ false.
	do _ dataObjs copyTwoLevel.  ds _ dataStrs copy.
	(dataObjs last isKindOf: (classes at: ansInd)) ifTrue: [
		((ansSel ~~ #first) or: [dataObjs last size = 1]) ifTrue: [
			do at: do size put: (do last perform: ansSel).	"asString"
			ds at: ds size put: ds last, ' ', ansSel.
			result _ MethodFinder new load: do; findMessage.
			(result first beginsWith: 'no single method') ifFalse: [
				"found a selector!"
				^ Array with: result first with: do with: ds].	
			answerMod _ true]].

	selectors allButLast withIndexDo: [:argSel :argInd | "Modify an argument object"
			"for args, no reason to do Array -> OrderedCollection.  Identical protocol."
		didUnmodifiedAnswer not | answerMod ifTrue: [
		ddo _ do copyTwoLevel.  dds _ ds copy.
		dataObjs first withIndexDo: [:arg :ind |
			(arg isKindOf: (classes at: argInd))  ifTrue: [
				((argSel ~~ #first) or: [arg size = 1]) ifTrue: [
					ddo first at: ind put: ((ddo first at: ind) perform: argSel).	"asString"
					dds at: ind put: (dds at: ind), ' ', argSel.
					result _ MethodFinder new load: ddo; findMessage.
					(result first beginsWith: 'no single method') ifFalse: [
						"found a selector!"
						^ Array with: result first with: ddo with: dds]	.	
					didUnmodifiedAnswer not & answerMod not ifTrue: [
						didUnmodifiedAnswer _ true].
					]]]]].
	].
^ Array with: 'no single method does that function' with: dataObjs with: dataStrs