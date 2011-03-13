generateNormalResolverTests
	"TestURI generateNormalResolverTests"

	| relURIString result method testPairs pair |

	testPairs _ #(
		#('g:h' 'g:h' )
		#('g' 'http://a/b/c/g' )
		#('./g' 'http://a/b/c/g' )
		#('g/' 'http://a/b/c/g/' )
		#('/g' 'http://a/g' )
		#('//g' 'http://g' )
		#('?y' 'http://a/b/c/?y' )
		#('g?y' 'http://a/b/c/g?y' )
		#('g#s' 'http://a/b/c/g#s' )
		#('g?y#s' 'http://a/b/c/g?y#s' )
		#(';x' 'http://a/b/c/;x' )
		#('g;x' 'http://a/b/c/g;x' )
		#('g;x?y#s' 'http://a/b/c/g;x?y#s' )
		#('.' 'http://a/b/c/' )
		#('./' 'http://a/b/c/' )
		#('..' 'http://a/b/' )
		#('../' 'http://a/b/' )
		#('../g' 'http://a/b/g' )
		#('../..' 'http://a/' )
		#('../../' 'http://a/' )
		#('../../g' 'http://a/g' )
	).
	1 to: testPairs size do: [:index |
		pair _ testPairs at: index.
		relURIString _ pair first.
		result _ pair last.
		method _ String streamContents: [:stream |
			stream nextPutAll: 'testResolveNormal' , index printString; cr.
			stream
				nextPutAll: '	| baseURI relURI resolvedURI |' ; cr;
				nextPutAll: '	baseURI _ ''http://a/b/c/d;p?q'' asURI.' ; cr;
				nextPutAll: '	relURI _ '; nextPut: $'; nextPutAll: relURIString; nextPutAll: '''.' ; cr;
				nextPutAll: '	resolvedURI _ baseURI resolveRelativeURI: relURI.' ; cr;
				nextPutAll: '	self should: [resolvedURI asString = '''; nextPutAll: result; nextPutAll: '''].' ; cr].
		self compile: method classified: 'running resolving'].
