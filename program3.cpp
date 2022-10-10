#include<iostream>
#include<vector>
#include<queue>
using namespace std;
struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};
vector<int> levelOrder(TreeNode* root) {
    vector<int> res;
    queue<TreeNode*> que;
    bool flag = false;
    if (root) que.push(root);
    while (!que.empty())
    {
        vector<int> tmp;
        for (int i = que.size(); i > 0; --i)
        {
            auto node = que.front();
            if (flag == false) { res.push_back(node->val); flag = true; }
            if (node->left)que.push(node->left);
            if (node->right) que.push(node->right);
            que.pop();
        }
        flag = false;
    }
    return res;
}
int main()
{
    TreeNode* head =new TreeNode(1);
    TreeNode* left = new TreeNode(2);
    TreeNode* right = new TreeNode(3);
	TreeNode* l3=new TreeNode(4);
    head->left = left;
    head->right = right;
	left->left=l3;
    auto vec = levelOrder(head);
    for (int num : vec)
    {
        cout << num;
    }
    return 0;
}
