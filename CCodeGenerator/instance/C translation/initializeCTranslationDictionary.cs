initializeCTranslationDictionary 
	"Initialize the dictionary mapping message names to actions for C code generation."

	| pairs |
	translationDict _ Dictionary new: 200.
	pairs _ #(
	#&				#generateAnd:on:indent:
	#|				#generateOr:on:indent:
	#and:			#generateSequentialAnd:on:indent:
	#or:			#generateSequentialOr:on:indent:
	#not			#generateNot:on:indent:

	#+				#generatePlus:on:indent:
	#-				#generateMinus:on:indent:
	#*				#generateTimes:on:indent:
	#//				#generateDivide:on:indent:
	#\\				#generateModulo:on:indent:
	#<<				#generateShiftLeft:on:indent:
	#>>				#generateShiftRight:on:indent:
	#min:			#generateMin:on:indent:
	#max:			#generateMax:on:indent:

	#bitAnd:		#generateBitAnd:on:indent:
	#bitOr:			#generateBitOr:on:indent:
	#bitXor:			#generateBitXor:on:indent:
	#bitShift:		#generateBitShift:on:indent:
	#bitInvert32	#generateBitInvert32:on:indent:

	#<				#generateLessThan:on:indent:
	#<=				#generateLessThanOrEqual:on:indent:
	#=				#generateEqual:on:indent:
	#>				#generateGreaterThan:on:indent:
	#>=				#generateGreaterThanOrEqual:on:indent:
	#~=				#generateNotEqual:on:indent:
	#==				#generateEqual:on:indent:
	#isNil			#generateIsNil:on:indent:
	#notNil			#generateNotNil:on:indent:

	#whileTrue: 	#generateWhileTrue:on:indent:
	#whileFalse:	#generateWhileFalse:on:indent:
	#to:do:			#generateToDo:on:indent:
	#to:by:do:		#generateToByDo:on:indent:

	#ifTrue:		#generateIfTrue:on:indent:
	#ifFalse:		#generateIfFalse:on:indent:
	#ifTrue:ifFalse:	#generateIfTrueIfFalse:on:indent:
	#ifFalse:ifTrue:	#generateIfFalseIfTrue:on:indent:

	#at:				#generateAt:on:indent:
	#at:put:			#generateAtPut:on:indent:
	#basicAt:		#generateAt:on:indent:
	#basicAt:put:	#generateAtPut:on:indent:

	#integerValueOf:	#generateIntegerValueOf:on:indent:
	#integerObjectOf:	#generateIntegerObjectOf:on:indent:
	#isIntegerObject: 	#generateIsIntegerObject:on:indent:
	#cCode:				#generateInlineCCode:on:indent:
	#cCoerce:to:			#generateCCoercion:on:indent:
	#preIncrement		#generatePreIncrement:on:indent:
	#preDecrement		#generatePreDecrement:on:indent:
	#inline:				#generateInlineDirective:on:indent:
	#sharedCodeNamed:inCase:	#generateSharedCodeDirective:on:indent:
	).

	1 to: pairs size by: 2 do: [ :i |
		translationDict at: (pairs at: i) put: (pairs at: i + 1).
	].