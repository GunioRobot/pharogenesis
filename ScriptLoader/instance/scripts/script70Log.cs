script70Log

"
Name: Compiler-lr.50
Author: lr
Time: 9 July 2006, 7:56:43 pm
UUID: 47ef9423-0f74-11db-b64a-000a9573eae2
Ancestors: Compiler-lr.49

- fixed more pragma bugs (throw an error for <1> and <foo bar>)
Name: Collections-pmm.68
Author: pmm
Time: 9 July 2006, 11:53:56 am
UUID: 20686bef-7acd-4afc-a610-a4485c82ffb1
Ancestors: Collections-sd.67

changes with respect to: http://bugs.impara.de/view.php?id=1876
- changed Set class >> #new: according to comments of ar, this fixes the hiccup at around 4k elements
- removed the progress bar from Set class >> #rehash all sets. This allows to load the changesets and makes in possibly faster (old version waits 2ms for each set when querying the mouse position)

Name: Balloon-ar.13
Author: ar
Time: 5 April 2006, 12:23:02 am
UUID: bdaaa697-27c2-4049-a7e8-13e44a41f929
Ancestors: Balloon-ar.11

- replace underscore assignment with colon-equals
Name: Compression-ar.8
Author: ar
Time: 5 April 2006, 12:25:07 am
UUID: 3c075d58-b256-704c-9870-6998a0c8e9ce
Ancestors: Compression-ar.6

- replace underscore assignment with colon-equals

Name: FFI-ar.11
Author: ar
Time: 8 July 2006, 9:25:14 pm
UUID: e964ce57-a9a6-2a4e-9572-685f6b711fba
Ancestors: FFI-ar.10

- include non-Mantis fixes

Name: Flash-ar.5
Author: ar
Time: 8 July 2006, 9:21:53 pm
UUID: d7099247-3e7a-d742-921d-8dd73cf0fa07
Ancestors: Flash-ar.4

- include improved image supports

Name: Graphics-ar.38
Author: ar
Time: 8 July 2006, 8:51:07 pm
UUID: 38143d92-893f-ec4f-9882-0e7d947ca710
Ancestors: Graphics-ar.37

- include fix for BitBlt rounding

Name: GraphicsTests-ar.9
Author: ar
Time: 8 July 2006, 7:08:18 pm
UUID: ce2beab2-9473-4d49-8302-b959486e7bf8
Ancestors: GraphicsTests-ar.8

- Integrate http://bugs.impara.de/view.php?id=3804
"
