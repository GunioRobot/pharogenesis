storeDataOn: aDataStream
	"Store myself on a DataStream. This is a low-level DataStream/ReferenceStream method. See also objectToStoreOnDataStream.  Need this to share tabsArray and marginTabsArray.  Fonts will take care of themselves.  "
	| cntInstVars cntIndexedVars instVars ti tm |

	cntInstVars _ self class instSize.
	cntIndexedVars _ self basicSize.
	instVars _ self class allInstVarNames.
	ti _ (instVars indexOf: 'tabsArray').
	tm _ (instVars indexOf: 'marginTabsArray').
	(ti = 0) | (tm = 0) | (ti > tm) ifTrue: [self error: 'this method is out of date'].
	aDataStream
		beginInstance: self class
		size: cntInstVars + cntIndexedVars.
	1 to: ti-1 do:
		[:i | aDataStream nextPut: (self instVarAt: i)].
	tabsArray == DefaultTabsArray 
		ifTrue: [aDataStream nextPut: (DiskProxy global: #TextConstants selector: #at: 
						args: #(DefaultTabsArray))]
		ifFalse: [aDataStream nextPut: tabsArray].
	ti+1 to: tm-1 do:
		[:i | aDataStream nextPut: (self instVarAt: i)].
	marginTabsArray == DefaultMarginTabsArray
		ifTrue: [aDataStream nextPut: (DiskProxy global: #TextConstants selector: #at: 
						args: #(DefaultMarginTabsArray))]
		ifFalse: [aDataStream nextPut: marginTabsArray].
	tm+1 to: cntInstVars do:
		[:i | aDataStream nextPut: (self instVarAt: i)].
	1 to: cntIndexedVars do:
		[:i | aDataStream nextPut: (self basicAt: i)]