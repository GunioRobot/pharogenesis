script65
	"network team + new version of MC with merging 296-297->303
		
	Name: System-gk.45
Author: gk
Time: 21 October 2005, 11:58:31 am
UUID: f8210799-b1de-5f46-b675-8c7b83550503
Ancestors: System-gk.44

Two good refactorings based on work from Bernard Pieber for Mantis #861 in the Network package. These depend on changes in the Network package:
 
- Project class>>fromUrl:
- ProjectLoading class>>bestAccessToFileName:andDirectory:

This also removes the only sender of Project class>>serverFileFromURL: and we could nuke it, but we leave that decision for the System stewards. :)"

"Name: Network-sd.30
Author: sd
Time: 29 May 2006, 9:29:37 pm
UUID: 6da57032-4ee0-412e-830a-e6169251929e
Ancestors: Network-KLC.27, Network-tb.28, Network-tb.29

merge 
Network-tb-29, tb-28, KLC27 with netweork-md.27

Name: Network-tb.29
Author: tb
Time: 24 May 2006, 10:23:58 pm
UUID: dfdd5a1c-4494-41da-afff-925a1597b1c3
Ancestors: Network-md.27

Fixes to address http://bugs.impara.de/view.php?id=2107  FileDirectory class>>retrieveMIMEDocument: class non-existent MIMEType class>forExtension:

Name: Network-tb.28
Author: tb
Time: 24 May 2006, 9:10:03 pm
UUID: 75f7e92a-6087-4223-a373-9d6516cd35e1
Ancestors: Network-md.27

Fix for http://bugs.impara.de/view.php?id=2454 - correctly set accent-type in HttpUrl retrieveContents so fetches of .css files succeed

Name: Network-KLC.27
Author: KLC
Time: 3 April 2006, 11:18 am
UUID: b2510551-ffee-4449-94c5-48d8c31bef77
Ancestors: Network-md.26, Network-gk.18, Network-KLC.21, Network-gk.23

This is a merge of:

Network-gk.18.mcz
Network-KLC.21.mcz
Network-gk.23.mcz

Combined notes:

Network-gk.18:

Changes:

- Adds #fileName to FileUrl and HierarchicalUrl (with HttpUrl as subclass), ok - I think that is fair even if the last part of the path not necessarily denotes a file.
- Adds Url class>>directoryUrl to FileUrl and HierarchicalUrl (with HttpUrl as subclass) which simply returns a new URL with the last element in the path removed.
- Adds #absoluteFromFileNameOrUrlString: which then is used from two different places (refactoring).
- A fix so that copying a URL does not share the path collection with the original. Not sure exactly if this has caused an actual bug yet, but I agree it is a good idea to not share.
- Fix bug in FileUrl>>pathForDirectory which used an explicit pathname delimiter in one place. Duh.
- Removed class MswUrl, sorry but this should not be in standard Network package IMHO. There is no use of it in the current image.

Non behavior changes:

- Refactoring adding Url class>>urlClassForScheme:.
- Improved naming in ServerDirectory class>>serverForURL:, no actual code change.
- Refines and adds lots of comments here and there.

Differences from proposed changes from Bernard Pieber in Mantis #861:

- Did not include the proposed HierarchicalPath>>pathForDirectory because it doesn t return a path (like the same method in FileUrl does), instead it returns a URL turned into a String. I changed the few senders that Bernard Pieber (Mantis #861) introduced to directoryUrl asString instead.
- Did not add isSuperSwikiUrl, it does not belong there. It is a hack from the start.

Network-KLC.19:

This is an adaptation of the updated provided by Patrick Mauritz at Mantis ID #0411:

Change Set: Enh-ConnectionQueue
Date: 16 October 2004
Author: Patrick Mauritz

Allow classes to subscribe to the ConnectionQueue via addDependent: to get notifications when new connections are opened.
Receivers need to implement update:aSocket for this to work.
Thanks to Ken Causey for guidance on IRC.

I adapted Patrick s changes to ConnectionQueue>>listenLoop the result being that a check for a ConnectedTimedOut exception is added and a call to self changed on successful connection. Otherwise this should be the same as previously in the image.

Network-KLC.20:

As reported in Mantis ID #2106 this method included a call to the now non-existent Notification class>deprecated method. I ve replaced that call. With what I think is the appropriate mechanism.

The next question is at what point do deprecated methods get removed entirely?

Network-KLC.21:

This removes 3 methods that had no implementation other than calls to self halt. None of the 3 methods were being used and it didn t appear that they would likely ever be used.

Network-gk.23:

Fix for Mantis #2119, the simplest one described.

Fix for Mantis #1585, moved 3 test methods from OldSocket class to Socket and updated the code so that it works.

Doing the above I also fixed an issue in
Socket>>waitForDisconnectionFor:, it was wrongly waiting on semaphore instead of self readSemaphore. I also removed an unnecessary call to dataAvailable, unneeded temp var #extraBytes etc. The problem was that loopbackTest randomly hung in this method.

Optimized Socket>>discardReceivedData, unneeded call to dataAvailable removed.

Better class comments in ProtocolClient, Socket and SocketStream.

Improved comment in Socket>>closeAndDestroy:'


	Name: Monticello-al.297
	
	Time: 9 May 2006, 4:54:21 pm
	UUID: bc893983-a6cd-430c-bf5d-a4d60fdb04b3
	Ancestors: Monticello-al.295

	- fix loading traits with empty trait composition

New version merging 296 and 297 -> MC 303!
"

	| names|
names := '39Deprecated-md.11.mcz
Balloon-mir.11.mcz
Collections-sd.63.mcz
CollectionsTests-sd.27.mcz
Compiler-sd.48.mcz
Compression-stephaneducasse.4.mcz
EToys-md.20.mcz
Exceptions-md.7.mcz
FFI-CdG.4.mcz
Files-md.16.mcz
FixInvisible-bf.1.mcz
FixUnderscores-md.9.mcz
Flash-md.3.mcz
FlexibleVocabularies-al.5.mcz
Graphics-md.35.mcz
GraphicsTests-ar.8.mcz
Kernel-al.126.mcz
KernelTests-sd.37.mcz
Monticello-sd.303.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Morphic-sd.96.mcz
MorphicExtras-md.27.mcz
MorphicTests-stephaneducasse.4.mcz
Movies-md.7.mcz
Multilingual-md.20.mcz
Nebraska-md.10.mcz
Network-sd.30.mcz
NetworkTests-gk.8.mcz
OB-Standard-sd.106.mcz
OmniBrowser-lr.281.mcz
PackageInfo-stephaneducasse.5.mcz
PlusTools-md.34.mcz
PreferenceBrowser-md.30.mcz
Protocols-md.12.mcz
ReleaseBuilder-md.4.mcz
ScriptLoader-sd.189.mcz
Services-Base-md.27.mcz
SMBase-md.72.mcz
SMLoader-md.29.mcz
SmaCC-fbs.8.mcz
Sound-md.6.mcz
Speech-md.8.mcz
ST80-md.33.mcz
StarSqueak-sd.6.mcz
SUnit-md.32.mcz
SUnitGUI-sd.7.mcz
System-sd.86.mcz
SystemChangeNotification-Tests-sd.5.mcz
Tests-md.17.mcz
ToolBuilder-Kernel-sd.15.mcz
ToolBuilder-Morphic-stephaneducasse.16.mcz
ToolBuilder-MVC-dtl.12.mcz
ToolBuilder-SUnit-stephaneducasse.10.mcz
Tools-md.68.mcz
Traits-al.220.mcz
TrueType-md.2.mcz
VersionNumber-dew.1.mcz'
findTokens: ' ', String cr.

	self loadTogether: names merge: true.