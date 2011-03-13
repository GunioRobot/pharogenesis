script73Log

	"	
	Name: Graphics-ar.39
Author: ar
Time: 13 July 2006, 11:01:44 am
UUID: 8493073d-14aa-7643-9a13-574d84f7b2c3
Ancestors: Graphics-ar.38

- include fix from http://bugs.impara.de/view.php?id=3570
+ test

http://squeaksource.com/ToolBuilder/ToolBuilder-Kernel-ar.16.mcz
http://squeaksource.com/ToolBuilder/ToolBuilder-Morphic-ar.19.mcz
http://squeaksource.com/ToolBuilder/ToolBuilder-SUnit-ar.11.mcz
http://squeaksource.com/ToolBuilder/ToolBuilder-MVC-dtl.12.mcz

The main change is that some support for menus has been added.

Name: CollectionsTests-md.31
Author: md
Time: 14 July 2006, 12:38:43 pm
UUID: 58b1f6ed-6778-4e8b-a006-6a3a42c75b5a
Ancestors: CollectionsTests-sd.30, CollectionsTests-dc.29


0003829: [FIX] Better tests for Stack
Description
I modify my tests for the Stack class. They do not call private methods anymore.

----------------------------


Name: Collections-md.69
Author: md
Time: 14 July 2006, 12:36:25 pm
UUID: 6164f840-096e-4191-b280-9a492bea167f
Ancestors: Collections-pmm.68

0003887: SequenceableCollection>>, wrong comment

----------------------------

Name: Kernel-md.139
Author: md
Time: 14 July 2006, 12:42:52 pm
UUID: 7de16533-743b-438b-84ac-e57243b709a4
Ancestors: Kernel-sd.138

In 3.9b-7029, WeakMessageSendTest fails for lack of class comments. I spent about a hour studying the class and provided a reasonable class comment.
All KernalTests-Objects now run green.

- fix for Paragrapheditor>>#prettyPrint:

----------------------------

	
	"