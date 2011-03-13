script68Log

"
Name: Kernel-pmm.130
Author: pmm
Time: 6 July 2006, 8:59:24 pm
UUID: ca825d54-f890-4bcb-be38-4a718f29459b
Ancestors: Kernel-al.129

- fix browsing with alt+b for globals like Smalltalk
- push #isTrait to Object like #isBehavior

Name: Kernel-al.129
Author: al
Time: 3 July 2006, 3:58:12 pm
UUID: ea1c48cf-2455-4fa5-ad13-75616626321b
Ancestors: Kernel-sd.128

- small fix of the ClassBuilder (when redefining a class, its class side traits were lost)

Name: Collections-lr.64
Author: lr
Time: 7 July 2006, 11:33:53 am
UUID: b45346c1-0d9b-11db-a7b8-000a9573eae2
Ancestors: Collections-sd.63

- revert string comparison to the 3.7 behavior


Name: CollectionsTests-lr.28
Author: lr
Time: 7 July 2006, 11:34:31 am
UUID: cac623bf-0d9b-11db-a7b8-000a9573eae2
Ancestors: CollectionsTests-sd.27

- revert string comparison to the 3.7 behavior

Name: OB-Standard-al.112
Author: al
Time: 7 July 2006, 11:14:56 am
UUID: fd3a8638-1e50-45b5-ad4a-f5224054a331
Ancestors: OB-Standard-pmm.111

- manually merged in Alex' enhancement:

Enhancement: When you find a class by pressing Alt-f for example, you may have a very long list. Even if you type the exact name of the class. This changeset place as the first choice the class you entered.

For instance, try to search for Object. You have a very long list, this change makes Object the first entry of the menu
"
