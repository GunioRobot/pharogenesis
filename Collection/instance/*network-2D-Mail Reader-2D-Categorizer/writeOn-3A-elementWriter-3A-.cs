writeOn: aStream elementWriter: aBlock
	 aStream nextWordPut: self size.
	 self do: [:x | aBlock value: aStream value: x].