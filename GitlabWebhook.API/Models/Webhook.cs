using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitlabWebhook.API.Models
{
    public class Webhook
    {
        public string object_kind { get; set; }
        public string before { get; set; }
        public string after { get; set; }
        public string Ref { get; set; }
        public string checkout_sha { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_username { get; set; }
        public string user_email { get; set; }
        public string user_avatar { get; set; }
        public int project_id { get; set; }
        public Project project { get; set; }
        public Repository repository { get; set; }
        public Commit[] commits { get; set; }
        public Commit commit { get; set; }
        public int total_commits_count { get; set; }

        public ObjectAttributes object_attributes { get; set; }
        public User user { get; set; }
    }

    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string web_url { get; set; }
        public string avatar_url { get; set; }
        public string git_ssh_url { get; set; }
        public string git_http_url { get; set; }
        public string Namespace { get; set; }
        public int visibility_level { get; set; }
        public string path_with_namespace { get; set; }
        public string default_branch { get; set; }
        public string homepage { get; set; }
        public string url { get; set; }
        public string ssh_url { get; set; }
        public string http_url { get; set; }
    }

    public class Repository
    {
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
        public string git_http_url { get; set; }
        public string git_ssh_url { get; set; }
        public int visibility_level { get; set; }
    }

    public class Commit
    {
        public string id { get; set; }
        public string message { get; set; }
        public string timestamp { get; set; }
        public string url { get; set; }
        public string[] added { get; set; }
        public string[] modified { get; set; }
        public string[] removed { get; set; }

        public Author author { get; set; }
    }

    public class Author
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class ObjectAttributes
    {
        public int id { get; set; }
        public string Ref { get; set; }
        public bool? tag { get; set; }
        public string sha { get; set; }
        public string before_sha { get; set; }
        public string source { get; set; }
        public string status { get; set; }
        public string[] stages { get; set; }
        public string created_at { get; set; }
        public string finished_at { get; set; }
        public int? duration { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string username { get; set; }
        public string avatar_url { get; set; }
    }
}
