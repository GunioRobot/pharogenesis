example
	"Here are the first two examples from the specification document (FIPS PUB 180-1)."
	"SecureHashAlgorithm example"

	| hash |
	hash _ SecureHashAlgorithm new hashMessage: 'abc'.
	hash = 16rA9993E364706816ABA3E25717850C26C9CD0D89D
		ifTrue: [self inform: 'Passed Test #1']
		ifFalse: [self error: 'Test #1 failed!'].

	hash _ SecureHashAlgorithm new hashMessage:
		'abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq'.
	hash = 16r84983E441C3BD26EBAAE4AA1F95129E5E54670F1 
		ifTrue: [self inform: 'Passed Test #2']
		ifFalse: [self error: 'Test #2 failed!'].
