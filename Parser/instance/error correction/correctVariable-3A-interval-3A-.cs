correctVariable: proposedVariable interval: spot
	"Correct the proposedVariable to a known variable, or declare it as a new
	variable if such action is requested.  We support declaring lowercase
	variables as temps or inst-vars, and uppercase variables as Globals or 
	ClassVars, depending on whether the context is nil (class=UndefinedObject).
	Spot is the interval within the test stream of the variable.
	rr 3/4/2004 10:26 : adds the option to define a new class. "

	| tempIvar labels actions lines alternatives binding userSelection choice action |

	"Check if this is an i-var, that has been corrected already (ugly)"
	(encoder classEncoding allInstVarNames includes: proposedVariable) ifTrue: [
		^LiteralVariableNode new 
			name: proposedVariable index: (encoder classEncoding allInstVarNames indexOf: proposedVariable) - 1 type: 1;
			yourself ].

	"If we can't ask the user for correction, make it undeclared"
	self interactive 
		ifFalse: [ ^encoder undeclared: proposedVariable ].

	"First check to see if the requestor knows anything about the variable"
	tempIvar _ proposedVariable first canBeNonGlobalVarInitial.
	(tempIvar and: [ (binding _ requestor bindingOf: proposedVariable) notNil ])
		ifTrue: [ ^encoder global: binding name: proposedVariable ].
	userSelection _ requestor selectionInterval.
	requestor selectFrom: spot first to: spot last.
	requestor select.

	"Build the menu with alternatives"
	labels _ OrderedCollection new. actions _ OrderedCollection new. lines _ OrderedCollection new.
	alternatives _ encoder possibleVariablesFor: proposedVariable.
	tempIvar 
		ifTrue: [ 
			labels add: 'declare temp'. 
			actions add: [ self declareTempAndPaste: proposedVariable ].
			labels add: 'declare instance'.
			actions add: [ self declareInstVar: proposedVariable ] ]
		ifFalse: [ 
			labels add: 'define new class'.
			actions add: [self defineClass: proposedVariable].
			labels add: 'declare global'.
			actions add: [ self declareGlobal: proposedVariable ].
			encoder classEncoding == UndefinedObject ifFalse: [ 
				labels add: 'declare class variable'.
				actions add: [ self declareClassVar: proposedVariable ] ] ].
	lines add: labels size.
	alternatives do: [ :each | 
		labels add: each.
		actions add: [ 
			self substituteWord: each wordInterval: spot offset: 0.
			encoder encodeVariable: each ] fixTemps ].
	lines add: labels size.
	labels add: 'cancel'.

	"Display the pop-up menu"
	choice _ (PopUpMenu labelArray: labels asArray lines: lines asArray)
		startUpWithCaption: 'Unknown variable: ', proposedVariable, ' please correct, or cancel:'.
	action _ actions at: choice ifAbsent: [ ^self fail ].

	"Execute the selected action"
	requestor deselect.
	requestor selectInvisiblyFrom: userSelection first to: userSelection last.
	^action value