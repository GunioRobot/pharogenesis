refreshChannelList
	"update the list of channels"
	| sortBlock |

	channelList _ connection channelList.
	channelList ifNil: [ channelList _ #() ].

	"sort the channels"
	sortCriterion = #name ifTrue: [
		sortBlock _ [ :a :b | a name asIRCLowercase < b name asIRCLowercase ] ]
	ifFalse: [
		sortBlock _ [ :a :b |
		a numUsers = b numUsers
			ifTrue: [ a name asIRCLowercase < b name asIRCLowercase ]
			ifFalse: [ a numUsers > b numUsers ] ] ].

	channelList _ channelList asSortedCollection: sortBlock.
	channelList _ channelList asArray.
	
	channelIndex _ 0.

	self changed: #channelDescriptions.
	self changed: #channelIndex.