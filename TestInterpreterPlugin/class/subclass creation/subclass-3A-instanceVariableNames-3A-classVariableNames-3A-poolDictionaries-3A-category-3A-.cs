subclass: nameOfClass  
	instanceVariableNames: instVarNames
	classVariableNames: classVarNames
	poolDictionaries: poolDictnames
	category: classCategory
	| stream |

	stream _ WriteStream on: ''.
	stream nextPutAll: 'TestInterpreterPlugin has been renamed to SmartSyntaxInterpreterPlugin.'; cr; nextPutAll: 'The old name will still work for this release (3.6)'; cr; nextPutAll:'but will result in this message appearing whenever a subclass is created.'; cr; nextPutAll:'It will not work in the next release'.
	self inform: stream contents.

	^ SmartSyntaxInterpreterPlugin
		subclass: nameOfClass
		instanceVariableNames: instVarNames
		classVariableNames: classVarNames
		poolDictionaries: poolDictnames
		category: classCategory
