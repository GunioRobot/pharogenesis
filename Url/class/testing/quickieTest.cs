quickieTest
	"run some quick tests on the Url hierarchy"
	"
	Url quickieTest
	"
	| tests url block correct actual numCorrect numWrong baseUrl |
	"each item in tests in a two-element array.  it has a block, followed by the string the block should evaluate to"

	tests _ OrderedCollection new.

	"parsing absolute urls of various kinds"

	tests add: (Array with: 
		[url _ 'hTTp://chaos.resnet.gatech.edu:8000/docs/java/index.html?A%20query%20#part' asUrl.
		url schemeName, '|', url authority, '|', url path first, '|', url path size printString, '|', url query, '|',url fragment.]
		with: 'http|chaos.resnet.gatech.edu:8000|docs|3|A%20query%20|part').

	tests add: (Array with:
		[url _ 'ftP://some.server/some/directory/' asUrl.
		url schemeName, '|', url class name, '|', url authority, '|', url path first , '|', url path size printString]
		with: 'ftp|FtpUrl|some.server|some|3').
	tests add: (Array with:
		[url _ 'telNet:chaos.resnet.gatech.edu#goo' asUrl.
		url schemeName, '|', url locator, '|', url fragment] 
		with: 'telnet|chaos.resnet.gatech.edu|goo').


	tests add: (Array with:
		[url _ Url absoluteFromText: 'file:/etc/passwd#foo'.
		url schemeName, '|', url path first, '|', url path size printString, '|', url fragment]
		with: 'file|etc|2|foo').


	tests add: (Array with: 
		[url _ Url absoluteFromText: 'browser:bookmarks#mainPart'.
		url schemeName, '|', url locator, '|', url fragment, '|', url class name ]
		with: 'browser|bookmarks|mainPart|BrowserUrl').


	tests add: (Array with:
		[url _ 'fILE:/foo/bar//zookie/?fakequery/#fragger' asUrl.
		url schemeName, '|', url class name, '|', url path first, '|', url path size printString, '|', url fragment]
		with: 'file|FileUrl|foo|5|fragger').


	"relative urls of each kind, relative to the original"
	tests add: (Array with: [
		baseUrl _ 'ftp://somewhere/some/dir/?query#fragment' asUrl.
		url _ baseUrl newFromRelativeText: 'ftp://a.b'.
		url toText]
		with: 'ftp://a.b/').

	tests add: (Array with: [
		baseUrl _ 'ftp://somewhere/some/dir/?query#fragment' asUrl.
		url _ baseUrl newFromRelativeText: 'ftp:xyz'.
		url toText.]
		with: 'ftp://somewhere/some/dir/xyz').

	tests add: (Array with: [
		baseUrl _ 'http://some.where/some/dir?query1#fragment1' asUrl.
		url _ baseUrl newFromRelativeText: '../another/dir/?query2#fragment2'.
		url toText]
		with: 'http://some.where/another/dir/?query2#fragment2').

	tests add: (Array with: [
		baseUrl _ 'file:/some/dir#fragment1' asUrl.
		url _ baseUrl newFromRelativeText: 'file:../another/dir/#fragment2'.
		url toText]
		with: 'file:/another/dir/#fragment2').

	"relative urls of a different scheme"
	tests add: (Array with: [
		baseUrl _ 'ftp://somewhere/some/dir/?query#fragment' asUrl.
		url _ baseUrl newFromRelativeText: 'http:xyz'.
		url toText.]
		with: 'http://xyz/').



	"run the tests"
	numCorrect _ 0.
	numWrong _ 0.
	tests do: [ :test |
		block _ test at: 1.
		correct _ test at: 2.
		actual _ block value.
		Transcript show: actual.
		correct = actual 
			ifTrue: [ numCorrect _ numCorrect + 1 ]
			ifFalse: [
				numWrong _ numWrong + 1.
				Transcript show: '<-- should be: ', correct ].
		Transcript cr. ].
	Transcript show: numCorrect printString, ' correct, ', numWrong printString, ' wrong.', String cr.
	numWrong > 0 
		ifTrue: [ Transcript show: 'happy hacking!' ]
		ifFalse: [ Transcript show: 'yay!!!' ].
	Transcript cr.