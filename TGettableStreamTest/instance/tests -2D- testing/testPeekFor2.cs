testPeekFor2
	| stream negative number |

	stream := self streamOn: '- 145'.
	negative := stream peekFor: $-.
	stream peekFor: Character space.
	number := stream next: 3.
	self assert: negative.
	self assert: number = '145'.

	stream := self streamOn: '-145'.
	negative := stream peekFor: $-.
	stream peekFor: Character space.
	number := stream next: 3.
	self assert: negative.
	self assert: number = '145'.
	
	stream := self streamOn: ' 145'.
	negative := stream peekFor: $-.
	stream peekFor: Character space.
	number := stream next: 3.
	self deny: negative.
	self assert: number = '145'.
	
	stream := self streamOn: '145'.
	negative := stream peekFor: $-.
	stream peekFor: Character space.
	number := stream next: 3.
	self deny: negative.
	self assert: number = '145'.