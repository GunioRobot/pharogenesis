byteEncode: aStream base: base
	(self printStringBase: base) do: [:each| aStream nextPut: $$; nextPut: each]
	