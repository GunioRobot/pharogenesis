generateAbnormalResolverTests
	"TestURI generateAbnormalResolverTests"

	| relURIString result method testPairs pair |

	testPairs _ #(
		#('../../../g' 'http://a/../g' )
		#('../../../../g' 'http://a/../../g' )
		#('/./g' 'http://a/./g' )
		#('/../g' 'http://a/../g' )
		#('g.' 'http://a/b/c/g.' )
		#('.g' 'http://a/b/c/.g' )
		#('g..' 'http://a/b/c/g..' )
		#('..g' 'http://a/b/c/..g' )
		#('./../g' 'http://a/b/g' )
		#('./g/.' 'http://a/b/c/g/' )
		#('g/./h' 'http://a/b/c/g/h' )
		#('g/../h' 'http://a/b/c/h' )
		#('g;x=1/./y' 'http://a/b/c/g;x=1/y' )
		#('g;x=1/../y' 'http://a/b/c/y' )
		#('g?y/./x' 'http://a/b/c/g?y/./x' )
		#('g?y/../x' 'http://a/b/c/g?y/../x' )
		#('g#s/./x' 'http://a/b/c/g#s/./x' )
		#('g#s/../x' 'http://a/b/c/g#s/../x' )
	).
	1 to: testPairs size do: [:index |
		pair _ testPairs at: index.
		relURIString _ pair first.
		result _ pair last.
		method _ String streamContents: [:stream |
			stream nextPutAll: 'testResolveAbnormal' , index printString; cr.
			stream
				nextPutAll: '	| baseURI relURI resolvedURI |' ; cr;
				nextPutAll: '	baseURI _ ''http://a/b/c/d;p?q'' asURI.' ; cr;
				nextPutAll: '	relURI _ '; nextPut: $'; nextPutAll: relURIString; nextPutAll: '''.' ; cr;
				nextPutAll: '	resolvedURI _ baseURI resolveRelativeURI: relURI.' ; cr;
				nextPutAll: '	self should: [resolvedURI asString = '''; nextPutAll: result; nextPutAll: '''].' ; cr].
		self compile: method classified: 'running resolving'].
