channelListReport
	"list the channels in a textual format"
	| list |
	list _ self channelList.
	list ifNil: [ ^'(info not available)' ].
	^String streamContents: [ :stream |
		stream nextPutAll: 'Channel List'; cr.
		stream nextPutAll: '--------------'; cr.
		list do: [ :channel |
			stream nextPutAll: channel name.
			stream nextPutAll: '('.
			stream nextPutAll: channel numUsers printString.
			stream nextPutAll: ')		['.
			stream nextPutAll: channel topic.
			stream nextPutAll: ']'.
			stream cr ] ]