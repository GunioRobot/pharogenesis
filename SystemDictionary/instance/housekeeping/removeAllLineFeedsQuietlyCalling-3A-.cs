removeAllLineFeedsQuietlyCalling: aBlock
	"Smalltalk removeAllLineFeedsQuietly"
	"Scan all methods for source code with lineFeeds.
	Replaces all occurrences of <CR><LF> or <LF> by <CR>.
	Answer a Dictionary keyed by author name containing sets of affected method names,
	as well as (at the key 'OK') a list of methods that still contain LF characters inside literal strings or characters.
	Evaluate aBlock for each method so that status can be updated."
	| oldCodeString newCodeString oldStamp oldCategory authors nameString |
	self forgetDoIts.
	authors := Dictionary new.
	authors at: 'OK' put: Set new.
	self systemNavigation
		allBehaviorsDo: [:cls | cls selectors
				do: [:selector | 
					aBlock value: cls value: selector.
					oldCodeString := cls sourceCodeAt: selector.
					(oldCodeString includes: Character lf)
						ifTrue: [
							newCodeString := oldCodeString withSqueakLineEndings.
							nameString := cls name , '>>' , selector.
							((cls compiledMethodAt: selector) hasLiteralSuchThat: [ :lit | lit asString includes: Character lf ])
								ifTrue: [(authors at: 'OK')
										add: nameString]
								ifFalse: [oldStamp := (Utilities
												timeStampForMethod: (cls compiledMethodAt: selector))
												copy replaceAll: Character cr
												with: Character space.
									(authors
										at: (oldStamp copyFrom: 1 to: (oldStamp findFirst: [ :c | c isAlphaNumeric not ]))
										ifAbsentPut: [Set new])
										add: nameString.
									oldCategory := cls whichCategoryIncludesSelector: selector.
									cls
										compile: newCodeString
										classified: oldCategory
										withStamp: oldStamp
										notifying: nil ]]]].
	^ authors