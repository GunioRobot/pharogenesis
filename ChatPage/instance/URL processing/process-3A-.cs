process: request 
	| author note |
	request fields isNil
		ifTrue: 
			[current isNil ifTrue: [current _ OrderedCollection new].
			request reply: (HTMLformatter evalEmbedded: (self fileContents: 'chat.html')
					with: current)]
		ifFalse: 
			[author _ request fields at: 'author'.
			note _ request fields at: 'note'.
			self add: '<b>' , author , '</b> 
			<i>' , Time now printString , '-' , Date today printString , '</i><p>' , note , '<p>'.
			request fields at: 'current' put: current.
			request reply: (HTMLformatter evalEmbedded: (self fileContents: 'chat.html')
					with: request)]