loadSqueakMap
	"Load the externally-maintained SqueakMap package if it is not already loaded.  Based on code by Göran Hultgren"

	| server addr answer |
	Socket initializeNetwork.
	server _ #('map1.squeakfoundation.org' 'map2.squeakfoundation.org' 'map.squeak.org' 'map.bluefish.se' 'marvin.bluefish.se:8000')
		detect: [:srv |
			addr _ NetNameResolver addressForName: (srv upTo: $:) timeout: 5.
			addr notNil and: [
				answer _ HTTPSocket httpGet: ('http://', srv, '/sm/ping').
				answer isString not and: [answer contents = 'pong']]]
		ifNone: [^ self inform: 'Sorry, no SqueakMap master server responding.'].
	server ifNotNil: ["Ok, found an SqueakMap server"
		ChangeSorter newChangesFromStream:
			((('http://', server, '/sm/packagebyname/squeakmap/downloadurl')
			asUrl retrieveContents content) asUrl retrieveContents content unzipped
			readStream)
		named: 'SqueakMap']