asURIForceEncoding
	"convert to a Url after we do the HTTP string safe encoding"
	"'http://www.cc.gatech.edu/'  asURIWithEncoding"
	"'msw://chaos.resnet.gatech.edu:9000/' asURIWithEncoding"
	^URI fromString: self encodeForHTTPAlternateSkipSlashColon