test1
"PNGReadWriter test1"
	| data t error d0 d1 f fileInfo book result d2 |

	Debugging _ true.
	1 = 1 ifTrue: [
		book _ BookMorph new.
		book setProperty: #transitionSpec toValue: {'silence'. #none. #none}.
	].
	d0 _ FileDirectory default.
	d1 _ d0 directoryNamed: 'PngSuite Folder'.
	d2 _ d0 directoryNamed: 'BIG PNG'.
	{d0. d1. d2}.		"keep compiler quiet"
"==
citrus_none_sub.png
citrus_adm7_adap.png
citrus_adm7_aver.png
citrus_adm7_non.png
citrus_adm7_paeth.png
pngs-img-ie5mac.png
=="
	fileInfo _ {
		d2. {'citrus_adm7_adap.png'}.
		"d1. d1 fileNames."
	}.
	fileInfo pairsDo: [ :dir :fileNames |
		fileNames do: [ :each |
			Transcript cr; show: each.
			data _ (dir fileNamed: each) contentsOfEntireFile.
			error _ ''.
			MessageTally spyOn: [
				t _ [
					result _ self createAFormFrom: data.
					f_ result first.
					error _ result second.
				] timeToRun.].
			self insertMorph: f asMorph named: each into: book.
			Transcript show: each,'  ',data size printString,' = ',t printString,' ms',error; cr.
		].
	].
	book ifNotNil: [book openInWorld].
	Debugging _ false.