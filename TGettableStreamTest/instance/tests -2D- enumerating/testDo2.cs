testDo2
	| stream string |
	stream := self streamOnArray.
	string := String new.
	
	stream do: [:value | string := string, ' ', value asString].
	
	self assert: string = (' ', 1 asString, ' ', #(a b c) asString, ' ', false asString)