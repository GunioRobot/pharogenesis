compileMessage: aText notifying: aController
	"Compile the code that was accepted by the user, placing the compiled method into an appropriate message category.  Return true if the compilation succeeded, else false."

	| fallBackCategoryIndex fallBackMethodIndex originalSelectorName result |

	self selectedMessageCategoryName ifNil:
			[ self selectOriginalCategoryForCurrentMethod 	
										ifFalse:["Select the '--all--' category"
											self messageCategoryListIndex: 1]]. 


	self selectedMessageCategoryName asSymbol = ClassOrganizer allCategory
		ifTrue:
			[ "User tried to save a method while the ALL category was selected"
			fallBackCategoryIndex _ messageCategoryListIndex.
			fallBackMethodIndex _ messageListIndex.
			editSelection == #newMessage
				ifTrue:
					[ "Select the 'as yet unclassified' category"
					messageCategoryListIndex _ 0.
					(result _ self defineMessageFrom: aText notifying: aController)
						ifNil:
							["Compilation failure:  reselect the original category & method"
							messageCategoryListIndex _ fallBackCategoryIndex.
							messageListIndex _ fallBackMethodIndex]
						ifNotNil:
							[self setSelector: result]]
				ifFalse:
					[originalSelectorName _ self selectedMessageName.
					self setOriginalCategoryIndexForCurrentMethod.
					messageListIndex _ fallBackMethodIndex _ self messageList indexOf: originalSelectorName.			
					(result _ self defineMessageFrom: aText notifying: aController)
						ifNotNil:
							[self setSelector: result]
						ifNil:
							[ "Compilation failure:  reselect the original category & method"
							messageCategoryListIndex _ fallBackCategoryIndex.
							messageListIndex _ fallBackMethodIndex.
							^ result notNil]].
			self changed: #messageCategoryList.
			^ result notNil]
		ifFalse:
			[ "User tried to save a method while the ALL category was NOT selected"
			^ (self defineMessageFrom: aText notifying: aController) notNil]