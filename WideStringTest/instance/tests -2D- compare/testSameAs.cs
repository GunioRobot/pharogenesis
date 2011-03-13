testSameAs
	"from johnmci at http://bugs.squeak.org/view.php?id=5331"

	self assert: ('abc' sameAs: 'aBc' asWideString).
	self assert: ('aBc' asWideString sameAs: 'abc').
	self assert: ((ByteArray with: 97 with: 0 with: 0 with: 0) asString sameAs: 'Abcd' asWideString) not.
	self assert: ('a000' asWideString sameAs: (ByteArray with: 97 with: 0 with: 0 with: 0) asString) not.
	