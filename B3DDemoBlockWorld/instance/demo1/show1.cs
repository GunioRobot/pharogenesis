show1

    " B3DDemoBlockWorld new show1"

     | view |

  self createScene1.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene1;
     scene: scene.
  view clearColor: (Color gray: 0.7).

  view panBy: (10@10@10);
       addDolly: 1.0;
       rotateY: 10.

  view openInSystemWindow.